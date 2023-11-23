--Создание таблиц--
CREATE TABLE ProductsNames(
id INT PRIMARY KEY IDENTITY, 
name VARCHAR(255) NOT NULL);

CREATE TABLE Category(
id INT PRIMARY KEY IDENTITY,
name VARCHAR(255) NOT NULL);

CREATE TABLE ProductsIDs(
products_id INT NOT NULL,
category_id INT NOT NULL,
FOREIGN KEY(products_id) REFERENCES ProductsNames(id) ON DELETE CASCADE,
FOREIGN KEY(category_id) REFERENCES Category(id) ON DELETE CASCADE);

CREATE UNIQUE INDEX productsIDs ON ProductsIDs(products_id, category_id);

--Заполнение таблиц--
INSERT INTO ProductsNames VALUES('Картофель'), ('Морковь'), ('Вилка');
INSERT INTO Category VALUES('Продукты питания'), ('Столовые приборы');
INSERT INTO ProductsIDs VALUES(1, 1), (2, 1), (3, 2); --Первый номер в скобке это номер продукта, в второй это номер категории--

--Задание--
SELECT p.name AS product, c.name AS category FROM ProductsNames AS p
LEFT JOIN ProductsIDs AS pc ON p.id = pc.products_id
INNER JOIN Category AS c ON c.id = pc.category_id
ORDER BY product;