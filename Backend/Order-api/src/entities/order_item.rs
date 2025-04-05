use bigdecimal::BigDecimal;
use diesel::prelude::{AsChangeset, Associations, Identifiable, Insertable, Queryable};
use crate::entities::order::Order;

#[derive(Debug, Insertable, Queryable, AsChangeset, Identifiable, Associations)]
#[diesel(table_name = crate::schema::orderitems)]
#[diesel(belongs_to(Order, foreign_key = order_id))]
pub struct OrderItem {
  pub id: String,
  pub quantity: i32,
  pub price: BigDecimal,
  pub product_id: String,
  pub order_id: String,
}