use diesel::prelude::{AsChangeset, Insertable, Queryable};
use serde::{Deserialize, Serialize};

#[derive(Serialize, Deserialize, Debug, Insertable, Queryable, AsChangeset)]
#[diesel(table_name = crate::schema::users)]
pub struct User {
    pub id: String,
    pub username: String
}