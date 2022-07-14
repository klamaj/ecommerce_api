-- PRODUCTS
-- (1,'RUG','A COOL RUG')
CREATE TABLE products(
    product_id int PRIMARY KEY,
    name VARCHAR(20),
    description VARCHAR(30)
);

-- VARIANTS
-- (1, 'COLOR')
-- (2, 'MATERIAL')
CREATE TABLE variants(
    variant_id int PRIMARY KEY,
    name VARCHAR(20)
);

-- VARIANT_VALUES
-- (1, 1, RED);
-- (2, 2, POLYESTER);
CREATE TABLE variant_values(
    value_id int PRIMARY KEY,
    variant_id int FOREIGN KEY REFERENCES varinats(variant_id),
    value VARCHAR(20)
);

-- PRODUCT_VARIANTS
-- (1, 1, 'RED-POLYESTER, 'A222' 50.00)
CREATE TABLE product_variants(
    product_variants_id PRIMARY KEY,
    product_id FOREIGN KEY REFERENCES products(product_id), -- UNIQUE --> PRODUCT_ID && PRODUCTVARIANTNAME
    productvarinatname VARCHAR(50),
    sku VARCHAR(50),
    price float
);