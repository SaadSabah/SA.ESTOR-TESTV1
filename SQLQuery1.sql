-- Laptops
INSERT INTO products (Name, Brand, Category, Price, Description, ImageFileName, CreatedAt, Email, TelephoneNumber) VALUES
    ('MacBook Pro 16"', 'Apple', 'Laptop', 2399.00, 'Powerful laptop with stunning display and M2 Pro chip.', 'macbook_pro_16.jpg', GETDATE(), 'example@gmail.com', 1234567890),
    ('Dell XPS 13', 'Dell', 'Laptop', 1199.00, 'Thin and light laptop with excellent battery life.', 'dell_xps_13.jpg', GETDATE(), 'example@gmail.com', 1234567890),
    ('HP Spectre x360', 'HP', 'Laptop', 1299.00, 'Convertible laptop with a sleek design and powerful performance.', 'hp_spectre_x360.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Lenovo ThinkPad X1 Carbon', 'Lenovo', 'Laptop', 1499.00, 'Durable business laptop with a comfortable keyboard.', 'lenovo_thinkpad_x1_carbon.jpg', GETDATE(), 'example@gmail.com', 1234567890),
    ('Asus ROG Zephyrus G14', 'Asus', 'Laptop', 1599.00, 'Gaming laptop with a compact form factor and powerful hardware.', 'asus_rog_zephyrus_g14.jpg', GETDATE(), 'example@gmail.com', 1234567890),
    ('Acer Swift 3', 'Acer', 'Laptop', 799.00, 'Affordable laptop with a good balance of performance and portability.', 'acer_swift_3.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Microsoft Surface Laptop 4', 'Microsoft', 'Laptop', 999.00, 'Premium laptop with a comfortable keyboard and stylish design.', 'microsoft_surface_laptop_4.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('LG Gram 16', 'LG', 'Laptop', 1299.00, 'Lightweight laptop with a large display and long battery life.', 'lg_gram_16.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Razer Blade 15', 'Razer', 'Laptop', 1999.00, 'High-performance gaming laptop with a sleek design.', 'razer_blade_15.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Samsung Galaxy Book Pro 360', 'Samsung', 'Laptop', 1399.00, 'Convertible laptop with an AMOLED display and S Pen support.', 'samsung_galaxy_book_pro_360.jpg', GETDATE(), 'example@yahoo.com', 1234567890),

-- Smartphones

    ('iPhone 14 Pro', 'Apple', 'Smartphone', 1099.00, 'Latest iPhone model with ProRes video and advanced camera system.', 'iphone_14_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Samsung Galaxy S23 Ultra', 'Samsung', 'Smartphone', 1199.00, 'Powerful Android phone with a stunning display and S Pen.', 'samsung_galaxy_s23_ultra.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Google Pixel 7 Pro', 'Google', 'Smartphone', 899.00, 'Android phone with exceptional camera capabilities and Google Tensor chip.', 'google_pixel_7_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('OnePlus 11', 'OnePlus', 'Smartphone', 799.00, 'Flagship-killer smartphone with fast charging and smooth performance.', 'oneplus_11.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Xiaomi 13 Pro', 'Xiaomi', 'Smartphone', 999.00, 'High-end smartphone with Leica-tuned cameras and fast charging.', 'xiaomi_13_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Motorola Edge 30 Pro', 'Motorola', 'Smartphone', 699.00, 'Affordable flagship phone with a fast refresh rate display and powerful processor.', 'motorola_edge_30_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Sony Xperia 1 IV', 'Sony', 'Smartphone', 1299.00, 'Unique smartphone with 4K OLED display and advanced camera features.', 'sony_xperia_1_iv.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Oppo Find X5 Pro', 'Oppo', 'Smartphone', 1099.00, 'Premium Android phone with Hasselblad-tuned cameras and fast charging.', 'oppo_find_x5_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Nothing Phone (1)', 'Nothing', 'Smartphone', 469.00, 'Distinctive smartphone with a transparent back and Glyph Interface.', 'nothing_phone_1.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Asus ROG Phone 6 Pro', 'Asus', 'Smartphone', 1299.00, 'Gaming smartphone with powerful hardware and unique design.', 'asus_rog_phone_6_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),

-- Smartwatches

    ('Apple Watch Series 8', 'Apple', 'Smartwatch', 399.00, 'Latest Apple Watch with health tracking, fitness features, and cellular options.', 'apple_watch_series_8.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Samsung Galaxy Watch 5 Pro', 'Samsung', 'Smartwatch', 449.00, 'Premium smartwatch with advanced health tracking and long battery life.', 'samsung_galaxy_watch_5_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Garmin Forerunner 955', 'Garmin', 'Smartwatch', 499.00, 'GPS smartwatch for runners and triathletes with advanced training features.', 'garmin_forerunner_955.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Fitbit Sense 2', 'Fitbit', 'Smartwatch', 299.00, 'Health-focused smartwatch with stress management and sleep tracking features.', 'fitbit_sense_2.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Google Pixel Watch', 'Google', 'Smartwatch', 349.00, 'First smartwatch from Google with Wear OS and Fitbit integration.', 'google_pixel_watch.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Amazfit GTR 4', 'Amazfit', 'Smartwatch', 199.00, 'Affordable smartwatch with a long battery life and stylish design.', 'amazfit_gtr_4.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Fossil Gen 6', 'Fossil', 'Smartwatch', 299.00, 'Fashionable smartwatch with Wear OS and various styles.', 'fossil_gen_6.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Huawei Watch GT 3 Pro', 'Huawei', 'Smartwatch', 369.00, 'Premium smartwatch with ECG and health monitoring features.', 'huawei_watch_gt_3_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('Polar Pacer Pro', 'Polar', 'Smartwatch', 299.00, 'Sports watch for runners and cyclists with training tools and GPS.', 'polar_pacer_pro.jpg', GETDATE(), 'example@yahoo.com', 1234567890),
    ('TicWatch Pro 5', 'Mobvoi', 'Smartwatch', 359.00, 'Dual-display smartwatch with Wear OS and long battery life.', 'ticwatch_pro_5.jpg', GETDATE(), 'example@yahoo.com', 1234567890);
