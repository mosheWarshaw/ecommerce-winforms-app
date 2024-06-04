--creation:

CREATE DATABASE ecommerce_site;
GO
use ecommerce_site;

CREATE TABLE [user] (
	id INT IDENTITY(1,1) PRIMARY KEY,
	username VARCHAR(20) NOT NULL,
	password VARCHAR(20) NOT NULL,
	balance DECIMAL(6, 2) NOT NULL
);

CREATE TABLE [order] (
	pk INT IDENTITY(1,1) PRIMARY KEY,
	user_id INT NOT NULL FOREIGN KEY REFERENCES [user](id),
	date DATE NOT NULL
);

CREATE TABLE purchase (
	pk INT IDENTITY(1,1) PRIMARY KEY,
	order_pk INT NOT NULL FOREIGN KEY REFERENCES [order](pk),

	--item_pk can refer to any of the item tables (tea or earbuds), and table_of_item_pk is the table name ('tea' or 'earbuds').
	--Have a storeed procedure that ensures referential integrity, because the db can't.
	item_pk INT NOT NULL,
	table_of_item_pk VARCHAR(30) NOT NULL,

	quantity INT NOT NULL
);

--The user filters what based on the item they are looking for, such as earbuds or tea or socks, and this gets
--filtered by categories, (if the item was socks, for eg:) by "steampunk" and "winter".

CREATE TABLE category (
	pk INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(30) NOT NULL
);

--//////////////////////////////////////////////////////////////////////
CREATE TABLE earbuds (
	pk INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(45) NOT NULL,
	price DECIMAL(5, 2) NOT NULL,
	quantity INT NOT NULL,
	for_sale BIT NOT NULL
);

--Is plural because each item can have multiple categories.
CREATE TABLE earbuds_categories (
	earbuds_pk INT NOT NULL FOREIGN KEY REFERENCES [earbuds](pk),
	category_pk INT NOT NULL FOREIGN KEY REFERENCES category(pk),
	CONSTRAINT pk_earbuds_categories PRIMARY KEY (earbuds_pk, category_pk)
);
--//////////////////////////////////////////////////////////////////////


--//////////////////////////////////////////////////////////////////////
CREATE TABLE tea (
	pk INT IDENTITY(1,1) PRIMARY KEY,
	name VARCHAR(45) NOT NULL,
	price DECIMAL(5, 2) NOT NULL,
	quantity INT NOT NULL,
	for_sale BIT NOT NULL
);

CREATE TABLE tea_categories (
	tea_pk INT NOT NULL FOREIGN KEY REFERENCES tea(pk),
	category_pk INT NOT NULL FOREIGN KEY REFERENCES category(pk),
	CONSTRAINT pk_tea_categories PRIMARY KEY (tea_pk, category_pk)
);
--//////////////////////////////////////////////////////////////////////




--population:


insert into category
(name)
values
('tech'),
('drink'),
('american'),
('british'),
('swedish'),
('japanese'),
('apple company'),
('microsoft company');

--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
insert into tea
(name, price, quantity, for_sale)
values
('jasmine tea', 5.75, 0, 1),
('white jade tea', 6.76, 1, 0),
('green tea caffeine free', 9.0, 20, 1),
('green tea caffeine', 5.0, 30, 1);


insert into tea_categories
(tea_pk, category_pk)
values
	((select pk from tea where name = 'jasmine tea'), (select pk from category where name = 'american')),
	((select pk from tea where name = 'white jade tea'), (select pk from category where name = 'british')),
	((select pk from tea where name = 'green tea caffeine free'), (select pk from category where name = 'swedish')),
	((select pk from tea where name = 'green tea caffeine'), (select pk from category where name = 'japanese')),

	((select pk from tea where name = 'jasmine tea'), (select pk from category where name = 'drink')),
	((select pk from tea where name = 'white jade tea'), (select pk from category where name = 'drink')),
	((select pk from tea where name = 'green tea caffeine free'), (select pk from category where name = 'drink')),
	((select pk from tea where name = 'green tea caffeine'), (select pk from category where name = 'drink'));
--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
insert into earbuds
(name, price, quantity, for_sale)
values
('apple wireless earbuds', 5.75, 30, 1),
('wired earbuds', 5.75, 30, 1);

insert into earbuds_categories
(earbuds_pk, category_pk)
values
	((select pk from earbuds where name = 'apple wireless earbuds'), (select pk from category where name = 'apple company')),
	((select pk from earbuds where name = 'apple wireless earbuds'), (select pk from category where name = 'tech')),

	((select pk from earbuds where name = 'wired earbuds'), (select pk from category where name = 'tech'));
--//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////