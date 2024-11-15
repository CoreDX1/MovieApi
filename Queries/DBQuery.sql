-- Create the Movies table
CREATE TABLE Movies (
  id SERIAL PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  synopsis TEXT,
  year INTEGER NOT NULL,
  duration INTEGER NOT NULL,
  genre VARCHAR(255) NOT NULL,
  image VARCHAR(255)
);

-- Create the Actors table
CREATE TABLE Actors (
  id SERIAL PRIMARY KEY,
  first_name VARCHAR(255) NOT NULL,
  last_name VARCHAR(255) NOT NULL,
  birthdate DATE
);

-- Create the Directors table
CREATE TABLE Directors (
  id SERIAL PRIMARY KEY,
  first_name VARCHAR(255) NOT NULL,
  last_name VARCHAR(255) NOT NULL,
  birthdate DATE
);

-- Create the Movies_Actors table
CREATE TABLE Movies_Actors (
  movie_id INTEGER NOT NULL,
  actor_id INTEGER NOT NULL,
  PRIMARY KEY (movie_id, actor_id),
  FOREIGN KEY (movie_id) REFERENCES Movies (id),
  FOREIGN KEY (actor_id) REFERENCES Actors (id)
);

-- Create the Movies_Directors table
CREATE TABLE Movies_Directors (
  movie_id INTEGER NOT NULL,
  director_id INTEGER NOT NULL,
  PRIMARY KEY (movie_id, director_id),
  FOREIGN KEY (movie_id) REFERENCES Movies (id),
  FOREIGN KEY (director_id) REFERENCES Directors (id)
);

-- Create the Comments table
CREATE TABLE Comments (
  id SERIAL PRIMARY KEY,
  movie_id INTEGER NOT NULL,
  text TEXT NOT NULL,
  date DATE NOT NULL,
  FOREIGN KEY (movie_id) REFERENCES Movies (id)
);

-- Insert sample data
INSERT INTO Movies (title, synopsis, year, duration, genre, image)
VALUES
  ('Schindler''s List', 
   'The story of Oskar Schindler, a businessman who saved over a thousand Polish-Jewish refugees during the Holocaust by employing them in his factories.',
   1993, 120, 'Drama', 
   'https://example.com/images/schindlers_list.jpg'),
   
  ('The Lord of the Rings', 
   'An epic tale of Middle-earth where Frodo Baggins, a hobbit, embarks on a journey to destroy the One Ring and save the world from Sauron.',
   2001, 180, 'Fantasy', 
   'https://example.com/images/lord_of_the_rings.jpg');

INSERT INTO Actors (first_name, last_name, birthdate)
VALUES
  ('Liam', 'Neeson', '1952-06-13'),
  ('Viggo', 'Mortensen', '1958-10-20');

INSERT INTO Directors (first_name, last_name, birthdate)
VALUES
  ('Steven', 'Spielberg', '1947-12-18'),
  ('Peter', 'Jackson', '1962-06-28');

INSERT INTO Movies_Actors (movie_id, actor_id)
VALUES
  (1, 1),
  (1, 2),
  (2, 2);

INSERT INTO Movies_Directors (movie_id, director_id)
VALUES
  (1, 1),
  (2, 2);

INSERT INTO Comments (movie_id, text, date)
VALUES
  (1, 'Excellent movie', '2022-01-01'),
  (2, 'I loved the trilogy', '2022-02-01');

select * from movies;


UPDATE movies SET movie_code = 'tt0108052' WHERE id = 1;
UPDATE movies SET movie_code = 'tt0167260' WHERE id = 2;
UPDATE movies SET movie_code = 'tt0803096' WHERE id = 3;
UPDATE movies SET movie_code = 'tt0078748' WHERE id = 4;
UPDATE movies SET movie_code = 'tt0090605' WHERE id = 5;
UPDATE movies SET movie_code = 'tt0370263' WHERE id = 6;
UPDATE movies SET movie_code = 'tt0088247' WHERE id = 7;

create table user(
  id serial primary key,
  name varchar(225),
  password_hash varchar(252),
  email varchar(225),
  created_at timestamp,
  updated_at timestamp
  last_login timestamp
)

create table rol(
  id serial primary key,
  name varchar(225) NOT NULL UNIQUE,
  created_at timestamp,
)

create table user_rol(
  user_id integer references user(id),
  rol_id integer references rol(id),
  primary key (user_id, rol_id)
)



