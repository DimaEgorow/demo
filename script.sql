create database demo_material5

CREATE TABLE partners (
    id INT PRIMARY KEY IDENTITY(1,1),
    type_partner NVARCHAR(10) NOT NULL,
    name_partner NVARCHAR(255) NOT NULL,
    director NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) NOT NULL,
    number_phone NVARCHAR(20) NOT NULL,
    address_partner NVARCHAR(255) NOT NULL,
    inn BIGINT NOT NULL,
    rating INT NOT NULL
);  

CREATE TABLE type_material (
    id INT PRIMARY KEY IDENTITY(1,1),
    type_material NVARCHAR(255) NOT NULL,
    percent_marriage FLOAT NOT NULL
);

CREATE TABLE type_product (
    id INT PRIMARY KEY IDENTITY(1,1),
    type_product NVARCHAR(255) NOT NULL,
    percent_marriage FLOAT NOT NULL
);

CREATE TABLE partner_product (
    id INT PRIMARY KEY IDENTITY(1,1),  
    partner_product_id INT NOT NULL REFERENCES product_import(id), -- Ссылка на id продукта партнера
    partner_id INT NOT NULL REFERENCES partners(id), -- Ссылка на id партнера
    count_product INT NOT NULL,
    date_sale DATETIME NOT NULL
);

CREATE TABLE product_import (
    id INT PRIMARY KEY IDENTITY(1,1),
    type_product_id INT NOT NULL REFERENCES type_product(id), -- Ссылка на id типа продукта
    name_product NVARCHAR(255) NOT NULL,
    articul INT NOT NULL,
    price FLOAT NOT NULL
);

INSERT INTO partners (type_partner, name_partner, director, email, number_phone, address_partner, inn, rating) VALUES
('ОАО', 'Строим вместе', 'Иванов Иван Иванович', 'qwerty@mail.ru', '799999999', 'ул. Пушкина 10', 0, 10),
('ЗАО', 'База Строитель', 'Иванова Александра Ивановна', 'aleksandraivanova@ml.ru', '493 123 45 67', '652050, Кемеровская область, город Юрга, ул. Лесная, 15', 22224551791, 7),
('ООО', 'Паркет 29', 'Петров Василий Петрович', 'vppetrov@vl.ru', '987 123 56 78', '164500, Архангельская область, город Северодвинск, ул. Строителей, 18', 3333888520, 7),
('ПАО', 'Стройсервис', 'Соловьев Андрей Николаевич', 'ansolovev@st.ru', '812 223 32 00', '188910, Ленинградская область, город Приморск, ул. Парковая, 21', 4440391035, 7),
('ОАО', 'Ремонт и отделка', 'Воробьева Екатерина Валерьевна', 'ekaterina.vorobeva@ml.ru', '444 222 33 11', '143960, Московская область, город Реутов, ул. Свободы, 51', 1111520857, 5),
('ЗАО', 'МонтажПро', 'Степанов Степан Сергеевич', 'stepanov@stepan.ru', '912 888 33 33', '309500, Белгородская область, город Старый Оскол, ул. Рабочая, 122', 5552431140, 10),
('ОАО', 'фыва', 'выфаыв', 'цуц', '123432', 'фыв', 0, 1);

 INSERT INTO product_import (type_product_id, name_product, articul, price) VALUES
(3, 'Ясень темный однополосная 14 мм', 8758385, 4456.9),
(3, 'Дуб Французская елка однополосная 12 мм', 8858958, 7330.99),
(1, 'Дуб дымчато-белый 33 класс 12 мм', 7750282, 1799.33),
(1, 'Дуб серый 32 класс 8 мм с фаской', 7028748, 3890.41),
(4, 'Пробковое напольное клеевое покрытие 32 класс 4 мм', 5012543, 5450.59);

INSERT INTO type_product (type_product, percent_marriage) VALUES
('Ламинат', 2.35),
('Массивная доска', 5.15),
('Паркетная доска', 4.34),
('Пробковое покрытие', 1.5);

INSERT INTO partner_product (partner_product_id, partner_id, count_product, date_sale) VALUES
(1, 1, 15500, 2023-03-23),
(3, 1, 12350, 2023-12-18),
(4, 1, 37400, 2024-06-07),
(2, 2, 35000, 2022-12-02),
(5, 2, 1250, 2023-05-17),
(4, 4, 59050, 2023-03-20),
(3, 4, 37200, 2024-03-12),
(5, 4, 4500, 2024-05-14),
(3, 5, 50000, 2023-09-19),
(4, 5, 670000, 2023-11-10),
(1, 5, 35000, 2024-04-15);