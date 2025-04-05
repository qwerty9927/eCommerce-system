use bigdecimal::BigDecimal;
use chrono::NaiveDateTime;
use diesel::prelude::{AsChangeset, Identifiable, Insertable, Queryable};

#[derive(Debug, Insertable, Queryable, AsChangeset, Identifiable)]
#[diesel(table_name = crate::schema::coupons)]
pub struct Coupon {
  pub id: String,
  pub name: Option<String>,
  pub description: Option<String>,
  pub code: String,
  pub discount: BigDecimal,
  pub quantity: i32,
  pub start_date: NaiveDateTime,
  pub expiration_date: NaiveDateTime,
  pub created_at: NaiveDateTime,
  pub updated_at: NaiveDateTime,
}