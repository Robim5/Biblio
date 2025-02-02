CREATE DATABASE Biblio;
USE Biblio;

-- table for users (sign up / sign in)
CREATE TABLE user (
    id_user INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    phone VARCHAR(15),
    email VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    image LONGBLOB,
    date_birth DATE,
    fines INT DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    is_adm boolean DEFAULT 0,
    favorite INT DEFAULT NULL,
    FOREIGN KEY (favorite) REFERENCES books (id_book)
);
-- to catagorize the books
CREATE TABLE categories (
    id_category INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(100) UNIQUE NOT NULL
);
-- table for books
CREATE TABLE books (
    id_book INT PRIMARY KEY AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255) NOT NULL,
    category_id INT,
    image LONGBLOB,
    adult BOOLEAN DEFAULT 0,
    FOREIGN KEY (category_id) REFERENCES categories (id_category) ON DELETE SET NULL
);
-- table for stores
CREATE TABLE stores (
    id_store INT PRIMARY KEY AUTO_INCREMENT,
    book_id INT,
    available INT DEFAULT 0,
    books_sold INT DEFAULT 0,
    books_requisited INT DEFAULT 0,
    name_store varchar(255),
    FOREIGN KEY (book_id) REFERENCES books (id_book) ON DELETE CASCADE
);
-- fines of each user (if any)
CREATE TABLE fines (
    id_fine INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT,
    cost DECIMAL(10,2) NOT NULL,
    date_given DATE NOT NULL,
    date_delivered DATE,
    FOREIGN KEY (user_id) REFERENCES user (id_user) ON DELETE CASCADE
);
-- requisitions of each user
CREATE TABLE requisitions (
    id_requi INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT, 
    book_id INT,
    store_id INT,
    date_requi DATE NOT NULL, 
    date_limit DATE NOT NULL,
    returned BOOLEAN DEFAULT 0,
    FOREIGN KEY (user_id) REFERENCES user (id_user) ON DELETE CASCADE,
    FOREIGN KEY (book_id) REFERENCES books (id_book) ON DELETE CASCADE,
    FOREIGN KEY (store_id) REFERENCES stores (id_store) ON DELETE CASCADE
);



