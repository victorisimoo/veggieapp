-- Creación de la base de datos
CREATE DATABASE veggiedb;

-- Selección de la base de datos
USE veggiedb;

-- Users table
CREATE TABLE users (
	idUser INT NOT NULL AUTO_INCREMENT,
	username VARCHAR(255) NOT NULL,
    typeUser INT DEFAULT 0,
	email VARCHAR(255) NOT NULL,
	password VARCHAR(255) NOT NULL,
	PRIMARY KEY (idUser),
	UNIQUE KEY email (email),
	UNIQUE KEY username (username)
);

-- Persons table
CREATE TABLE persons (
	idPerson INT NOT NULL AUTO_INCREMENT,
	idUser INT NOT NULL,
	firstName VARCHAR(255) NOT NULL,
	lastName VARCHAR(255) NOT NULL,
	address VARCHAR(255) NOT NULL,
	city VARCHAR(100) NOT NULL,
	state VARCHAR(100) NOT NULL,
	country VARCHAR(100) NOT NULL,
	phone VARCHAR(25) NOT NULL,
	PRIMARY KEY (idPerson),
	CONSTRAINT person_users_id FOREIGN KEY (idUser) REFERENCES users (idUser) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Sessions table
CREATE TABLE sessions (
	idSession INT NOT NULL AUTO_INCREMENT,
	idUser INT NOT NULL,
	token VARCHAR(255) NOT NULL,
	expires_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY (idSession),
	CONSTRAINT sessions_fk_user_id FOREIGN KEY (idUser) REFERENCES users (idUser) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Creation of the categories table
CREATE TABLE categories (
  idCategory INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(150) NOT NULL,
  PRIMARY KEY (idCategory)
);

-- Creation of the products table
CREATE TABLE products (
  idProduct INT NOT NULL AUTO_INCREMENT,
  name VARCHAR(150) NOT NULL,
  description VARCHAR(255) NOT NULL,
  price DECIMAL(10, 2) NOT NULL,
  idCategory INT NOT NULL,
  PRIMARY KEY (idProduct),
  KEY idCategory (idCategory),
  idUser INT,
  CONSTRAINT products_ibfk_1 FOREIGN KEY (idCategory) REFERENCES categories (idCategory) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Creation of the orders table
CREATE TABLE orders (
  idOrder INT NOT NULL AUTO_INCREMENT,
  idUser INT NOT NULL,
  date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  total DECIMAL(10, 2) NOT NULL,
  shipping_address VARCHAR(255) NOT NULL,
  shipping_city VARCHAR(255) NOT NULL,
  shipping_state VARCHAR(255) NOT NULL,
  shipping_country VARCHAR(255) NOT NULL,
  PRIMARY KEY (idOrder),
  KEY idUser (idUser),
  CONSTRAINT orders_ibfk_1 FOREIGN KEY (idUser) REFERENCES users (idUser) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Creation of the order products table
CREATE TABLE order_products (
  idOrderProducts INT NOT NULL AUTO_INCREMENT,
  idOrder INT NOT NULL,
  idProduct INT NOT NULL,
  quantity INT NOT NULL,
  unit_price DECIMAL(10, 2) NOT NULL,
  PRIMARY KEY (idOrderProducts),
  KEY idOrder (idOrder),
  KEY idProduct (idProduct),
  CONSTRAINT order_products_ibfk_1 FOREIGN KEY (idOrder) REFERENCES orders (idOrder) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT order_products_ibfk_2 FOREIGN KEY (idProduct) REFERENCES products (idProduct) ON DELETE CASCADE ON UPDATE CASCADE
);