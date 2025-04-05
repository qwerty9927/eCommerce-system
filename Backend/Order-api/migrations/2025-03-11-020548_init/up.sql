-- Your SQL goes here
CREATE TABLE Orders (
  id VARCHAR(255) PRIMARY KEY,
  status VARCHAR(50) NOT NULL,
  total_amount DECIMAL(10,2) NOT NULL,
  shipping_method VARCHAR(100) NOT NULL,
  shipping_cost DECIMAL(10,2) NOT NULL,
  payment_method VARCHAR(50) NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT now(),
  updated_at TIMESTAMP NOT NULL DEFAULT now(),
  user_id VARCHAR(255) NOT NULL,
  coupon_id VARCHAR(255),
  delivery_address_id VARCHAR(255)
);

CREATE TABLE OrderItems (
  id VARCHAR(255) PRIMARY KEY,
  quantity INT NOT NULL,
  price DECIMAL(10,2) NOT NULL,
  product_id VARCHAR(255) NOT NULL,
  order_id VARCHAR(255) NOT NULL
);

CREATE TABLE Transactions (
  id VARCHAR(255) PRIMARY KEY,
  amount DECIMAL(10,2) NOT NULL,
  status VARCHAR(50) NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT now(),
  updated_at TIMESTAMP NOT NULL DEFAULT now(),
  order_id VARCHAR(255) NOT NULL
);

CREATE TABLE DeliveryAddresses (
  id VARCHAR(255) PRIMARY KEY,
  address_line1 VARCHAR(255) NOT NULL,
  address_line2 VARCHAR(255),
  city VARCHAR(100) NOT NULL,
  state VARCHAR(100) NOT NULL,
  postal_code VARCHAR(20) NOT NULL,
  country VARCHAR(100) NOT NULL
);

CREATE TABLE Coupons (
  id VARCHAR(255) PRIMARY KEY,
  name VARCHAR(255),
  description TEXT,
  code VARCHAR(100) NOT NULL UNIQUE,
  discount DECIMAL(10,2) NOT NULL,
  quantity INT NOT NULL,
  start_date TIMESTAMP NOT NULL,
  expiration_date TIMESTAMP NOT NULL,
  created_at TIMESTAMP NOT NULL DEFAULT now(),
  updated_at TIMESTAMP NOT NULL DEFAULT now()
);


-- Add Foreign Key Constraints Using ALTER TABLE
ALTER TABLE Orders
ADD CONSTRAINT fk_orders_coupon FOREIGN KEY (coupon_id) REFERENCES Coupons(id) ON DELETE SET NULL,
ADD CONSTRAINT fk_orders_address FOREIGN KEY (delivery_address_id) REFERENCES DeliveryAddresses(id) ON DELETE SET NULL;

ALTER TABLE OrderItems
ADD CONSTRAINT fk_orderitems_order FOREIGN KEY (order_id) REFERENCES Orders(id) ON DELETE CASCADE;

ALTER TABLE Transactions
ADD CONSTRAINT fk_transactions_order FOREIGN KEY (order_id) REFERENCES Orders(id) ON DELETE CASCADE;
