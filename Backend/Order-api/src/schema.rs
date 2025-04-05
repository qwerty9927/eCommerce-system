// @generated automatically by Diesel CLI.

diesel::table! {
    coupons (id) {
        #[max_length = 255]
        id -> Varchar,
        #[max_length = 255]
        name -> Nullable<Varchar>,
        description -> Nullable<Text>,
        #[max_length = 100]
        code -> Varchar,
        discount -> Numeric,
        quantity -> Int4,
        start_date -> Timestamp,
        expiration_date -> Timestamp,
        created_at -> Timestamp,
        updated_at -> Timestamp,
    }
}

diesel::table! {
    deliveryaddresses (id) {
        #[max_length = 255]
        id -> Varchar,
        #[max_length = 255]
        address_line1 -> Varchar,
        #[max_length = 255]
        address_line2 -> Nullable<Varchar>,
        #[max_length = 100]
        city -> Varchar,
        #[max_length = 100]
        state -> Varchar,
        #[max_length = 20]
        postal_code -> Varchar,
        #[max_length = 100]
        country -> Varchar,
    }
}

diesel::table! {
    orderitems (id) {
        #[max_length = 255]
        id -> Varchar,
        quantity -> Int4,
        price -> Numeric,
        #[max_length = 255]
        product_id -> Varchar,
        #[max_length = 255]
        order_id -> Varchar,
    }
}

diesel::table! {
    orders (id) {
        #[max_length = 255]
        id -> Varchar,
        #[max_length = 50]
        status -> Varchar,
        total_amount -> Numeric,
        #[max_length = 100]
        shipping_method -> Varchar,
        shipping_cost -> Numeric,
        #[max_length = 50]
        payment_method -> Varchar,
        created_at -> Timestamp,
        updated_at -> Timestamp,
        #[max_length = 255]
        user_id -> Varchar,
        #[max_length = 255]
        coupon_id -> Nullable<Varchar>,
        #[max_length = 255]
        delivery_address_id -> Nullable<Varchar>,
    }
}

diesel::table! {
    transactions (id) {
        #[max_length = 255]
        id -> Varchar,
        amount -> Numeric,
        #[max_length = 50]
        status -> Varchar,
        created_at -> Timestamp,
        updated_at -> Timestamp,
        #[max_length = 255]
        order_id -> Varchar,
    }
}

diesel::table! {
    users (id) {
        #[max_length = 255]
        id -> Varchar,
        #[max_length = 100]
        username -> Varchar,
    }
}

diesel::joinable!(orderitems -> orders (order_id));
diesel::joinable!(orders -> coupons (coupon_id));
diesel::joinable!(orders -> deliveryaddresses (delivery_address_id));
diesel::joinable!(transactions -> orders (order_id));

diesel::allow_tables_to_appear_in_same_query!(
    coupons,
    deliveryaddresses,
    orderitems,
    orders,
    transactions,
    users,
);
