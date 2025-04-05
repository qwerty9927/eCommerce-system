use diesel::prelude::{AsChangeset, Identifiable, Insertable, Queryable};

#[derive(Debug, Insertable, Queryable, AsChangeset, Identifiable)]
#[diesel(table_name = crate::schema::deliveryaddresses)]
pub struct DeliveryAddress {
  pub id: String,
  pub address_line1: String,
  pub address_line2: Option<String>,
  pub city: String,
  pub state: String,
  pub postal_code: String,
  pub country: String,
}
