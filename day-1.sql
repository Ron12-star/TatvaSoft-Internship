
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS customer;


create table customer(
customer_id SERIAL PRIMARY KEY,
first_name varchar(100) NOT NULL,
last_name varchar(100) NOT NULL,
email varchar(100) UNIQUE NOT NULL
);

INSERT INTO customer (first_name, last_name, email)
VALUES
  ('Alice', 'Johnson', 'alice.johnson@example.com'),
  ('Bob', 'Smith', 'bob.smith@example.com'),
  ('Charlie', 'Brown', 'charlie.brown@example.com'),
  ('Diana', 'Lopez', 'diana.lopez@example.com'),
  ('Ethan', 'Davis', 'ethan.davis@example.com'),
  ('Fiona', 'Garcia', 'fiona.garcia@example.com'),
  ('George', 'Martin', 'george.martin@example.com'),
  ('Hannah', 'Lee', 'hannah.lee@example.com'),
  ('Isaac', 'Clark', 'isaac.clark@example.com'),
  ('Jenna', 'Wilson', 'jenna.wilson@example.com');

  SELECT * FROM customer;

ALTER table customer ADD COLUMN active BOOLEAN;
ALTER table customer RENAME COLUMN email to email_address;
SELECT * FROM customer;





CREATE TABLE orders(
order_id SERIAL PRIMARY KEY,
customer_id INTEGER NOT NULL REFERENCES customer(customer_id),
order_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),
order_number varchar(50) NOT NULL,
order_amount decimal NOT NULL
);
select * from orders;

INSERT INTO orders (customer_id, order_date, order_number, order_amount) VALUES
  (1, '2024-01-01', 'ORD001', 50.00),
  (2, '2024-01-01', 'ORD002', 35.75),
  (3, '2024-01-01', 'ORD003', 100.00),
  (4, '2024-01-01', 'ORD004', 30.25),
  (5, '2024-01-01', 'ORD005', 90.75),
  (6, '2024-01-01', 'ORD006', 25.50),
  (7, '2024-01-01', 'ORD007', 60.00),
  (8, '2024-01-01', 'ORD008', 42.00),
  (9, '2024-01-01', 'ORD009', 120.25),
  (10,'2024-01-01', 'ORD010', 85.00),
  (1, '2024-01-02', 'ORD011', 55.00),
  (1, '2024-01-03', 'ORD012', 80.25),
  (2, '2024-01-03', 'ORD013', 70.00),
  (3, '2024-01-04', 'ORD014', 45.00),
  (1, '2024-01-05', 'ORD015', 95.50),
  (2, '2024-01-05', 'ORD016', 27.50),
  (2, '2024-01-07', 'ORD017', 65.75),
  (2, '2024-01-10', 'ORD018', 75.50);

select * from orders;

select first_name from customer;
select first_name from customer order by first_name ASC;


select * from customer as c left join orders as o on c.customer_id=o.order_id