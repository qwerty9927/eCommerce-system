-- This file should undo anything in `up.sql`
Drop TABLE IF EXISTS OrderItems CASCADE;
Drop TABLE IF EXISTS Orders CASCADE;
Drop TABLE IF EXISTS Transactions CASCADE;
Drop TABLE IF EXISTS DeliveryAddresses CASCADE;
Drop TABLE IF EXISTS Coupons CASCADE;
-- Drop any other tables or constraints that were created in the up.sql
-- This is a placeholder for the actual SQL commands to drop the tables
-- and constraints created in the up.sql file.
-- Ensure that the database is in a clean state after this migration
-- and that all data is removed.