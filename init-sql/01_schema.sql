-- Create database
\c fitness_control;

-- Enable UUID extension for better ID generation
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- =====================================================
-- ENUMS AND LOOKUP TABLES
-- =====================================================

-- Exercise categories/lookup table
CREATE TABLE exercise_categories (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) UNIQUE NOT NULL,
    description TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
-- Muscle groups lookup
CREATE TABLE muscle_groups (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) UNIQUE NOT NULL
);

-- =====================================================
-- MAIN TABLES
-- =====================================================

-- User profile (static info, only one record)
CREATE TABLE users (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(30) NOT NULL,
    height DECIMAL(5,2) NOT NULL, -- in cm
    birth_date DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Exercises master table
CREATE TABLE exercises (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    category_id INTEGER REFERENCES exercise_categories(id),
    is_custom BOOLEAN DEFAULT false,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(name)
);

-- Index for date-based queries
CREATE INDEX idx_exercises_category ON exercises(category_id);

-- Exercise-muscle group junction table (many-to-many)
CREATE TABLE exercise_muscle_groups (
    exercise_id INTEGER REFERENCES exercises(id) ON DELETE CASCADE,
    muscle_group_id INTEGER REFERENCES muscle_groups(id) ON DELETE CASCADE,
    is_primary BOOLEAN DEFAULT true,
    PRIMARY KEY (exercise_id, muscle_group_id)
);


-- Index for date-based queries
CREATE INDEX idx_exercise_muscle_groups_exercise ON exercise_muscle_groups(exercise_id);
CREATE INDEX idx_exercise_muscle_groups_muscle ON exercise_muscle_groups(muscle_group_id);

-- =====================================================
-- WORKOUT TRACKING TABLES
-- =====================================================

-- Workout sessions (can contain multiple exercises)
CREATE TABLE workout_sessions (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    date DATE NOT NULL,
    notes TEXT, -- Overall workout notes
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Index for date-based queries
CREATE INDEX idx_workout_sessions_user_id ON workout_sessions(user_id);
CREATE INDEX idx_workout_sessions_date ON workout_sessions(date);
CREATE INDEX idx_workout_sessions_user_date ON workout_sessions(user_id, date);

-- Individual exercises performed in a workout
CREATE TABLE workout_exercises (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    workout_session_id UUID REFERENCES workout_sessions(id) ON DELETE CASCADE,
    exercise_id INTEGER NOT NULL REFERENCES exercises(id),
    order_number INTEGER NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(workout_session_id, order_number)
);

-- Index for date-based queries
CREATE INDEX idx_workout_exercises_workout_session ON workout_exercises(workout_session_id);
CREATE INDEX idx_workout_exercises_exercise ON workout_exercises(exercise_id);

-- Individual sets for each exercise
CREATE TABLE exercise_sets (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    workout_exercise_id UUID NOT NULL REFERENCES workout_exercises(id) ON DELETE CASCADE,
    set_number INTEGER NOT NULL,
    reps INTEGER NOT NULL,
    weight DECIMAL(6,2) NOT NULL, -- in kg
    comment TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(workout_exercise_id, set_number)
);

-- Index for date-based queries
CREATE INDEX idx_exercise_sets_workout_exercise ON exercise_sets(workout_exercise_id);

-- =====================================================
-- RUNNING TRACKING TABLES
-- =====================================================

-- Running sessions
CREATE TABLE running_sessions (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    date DATE NOT NULL,
    distance DECIMAL(6,2) NOT NULL, -- in kilometers
    duration INTERVAL NOT NULL, -- PostgreSQL interval type
    avg_pace INTERVAL GENERATED ALWAYS AS (duration / distance) STORED,  -- Auto-calculated
    avg_heart_rate INTEGER CHECK (avg_heart_rate >= 30 AND avg_heart_rate <= 250),
    max_heart_rate INTEGER CHECK (max_heart_rate >= 30 AND max_heart_rate <= 250),
    calories_burned INTEGER,
    notes TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Index for date-based queries
CREATE INDEX idx_running_sessions_user_id ON running_sessions(user_id);
CREATE INDEX idx_running_sessions_date ON running_sessions(date);
CREATE INDEX idx_running_sessions_user_date ON running_sessions(user_id, date);

-- =====================================================
-- MEASUREMENT TRACKING TABLES
-- =====================================================

-- Body measurements (tracked over time)
CREATE TABLE body_measurements (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    date DATE NOT NULL DEFAULT CURRENT_DATE,
    weight DECIMAL(5,2) NOT NULL,
    -- Circumferences (cm)
    chest DECIMAL(5,2),
    waist DECIMAL(5,2),
    hips DECIMAL(5,2),
    bicep DECIMAL(5,2),
    thigh DECIMAL(5,2),
    calf DECIMAL(5,2),
    notes TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    UNIQUE(user_id, date)
);

CREATE INDEX idx_body_measurements_user_id ON body_measurements(user_id);
CREATE INDEX idx_body_measurements_date ON body_measurements(recorded_date);

-- =====================================================
-- CREATE TRIGGER FUNCTION AND TRIGGERS
-- =====================================================

-- Function to auto-update updated_at
CREATE OR REPLACE FUNCTION update_updated_at_column()
RETURNS TRIGGER AS $$
BEGIN
    NEW.updated_at = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Apply to tables with updated_at
CREATE TRIGGER update_exercises_updated_at 
    BEFORE UPDATE ON exercises 
    FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();

CREATE TRIGGER update_workout_sessions_updated_at 
    BEFORE UPDATE ON workout_sessions 
    FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();

CREATE TRIGGER update_running_sessions_updated_at 
    BEFORE UPDATE ON running_sessions 
    FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();

CREATE TRIGGER update_users_updated_at 
    BEFORE UPDATE ON users 
    FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();
