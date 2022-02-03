INSERT INTO Companies VALUES ('BrainWare Company') -- 1
INSERT INTO Products VALUES ('Pipe fitting',1.23) -- 1
INSERT INTO Products VALUES ('10" straight',2.00) -- 2
INSERT INTO Products VALUES ('Quarter turn',0.75) -- 3
INSERT INTO Products VALUES ('5" straight',1.1) -- 4
INSERT INTO Products VALUES ('2" stright',0.90) -- 5

INSERT INTO [Orders] VALUES ('Our first order.', 1)
INSERT INTO [OrderProducts] VALUES (1, 1, 1.23, 10)
INSERT INTO [OrderProducts] VALUES (1, 3, 1.00, 3)
INSERT INTO [OrderProducts] VALUES (1, 4, 1.1, 22)

INSERT INTO [Orders] VALUES ('Our Second order.', 1)
INSERT INTO [OrderProducts] VALUES (2, 1, 1.23, 10)
INSERT INTO [OrderProducts] VALUES (2, 3, 1.00, 3)
INSERT INTO [OrderProducts] VALUES (2, 2, 2, 13)
INSERT INTO [OrderProducts] VALUES (2, 5, 0.9, 3)

INSERT INTO [Orders] VALUES ('Our third order.', 1)
INSERT INTO [OrderProducts] VALUES (3, 1, 1.23, 10)
INSERT INTO [OrderProducts] VALUES (3, 2, 2.00, 7)
INSERT INTO [OrderProducts] VALUES (3, 3, 0.75, 13)
INSERT INTO [OrderProducts] VALUES (3, 4, 1.1, 5)
INSERT INTO [OrderProducts] VALUES (3, 5, 0.9, 3)
