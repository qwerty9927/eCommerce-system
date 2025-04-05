use bigdecimal::BigDecimal;
use chrono::NaiveDateTime;
use diesel::prelude::{AsChangeset, Identifiable, Insertable, Queryable};

#[derive(Debug, Insertable, Queryable, AsChangeset, Identifiable)]
#[diesel(table_name = crate::schema::orders)]
pub struct Order {
  pub id: String,
  pub status: String,
  pub total_amount: BigDecimal,
  pub shipping_method: String,
  pub shipping_cost: BigDecimal,
  pub payment_method: String,
  pub created_at: NaiveDateTime,
  pub updated_at: NaiveDateTime,
  pub user_id: String,
  pub coupon_id: Option<String>,
  pub delivery_address_id: Option<String>
}