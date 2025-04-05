use bigdecimal::BigDecimal;
use chrono::NaiveDateTime;
use diesel::prelude::{AsChangeset, Associations, Identifiable, Insertable, Queryable};
use crate::entities::order::Order;

#[derive(Debug, Insertable, Queryable, AsChangeset, Identifiable, Associations)]
#[diesel(table_name = crate::schema::transactions)]
#[diesel(belongs_to(Order, foreign_key = order_id))]
pub struct Transaction {
  pub id: String,
  pub amount: BigDecimal,
  pub status: String,
  pub created_at: NaiveDateTime,
  pub updated_at: NaiveDateTime,
  pub order_id: String,
}