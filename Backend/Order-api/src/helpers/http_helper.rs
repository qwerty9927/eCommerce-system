use std::error::Error;
use serde::de::DeserializeOwned;

use reqwest::Response;

pub async fn get_async<T : DeserializeOwned>(url: &str) -> Result<T, Box<dyn Error>>{
  let response: Response = reqwest::get(url).await?;
  response_handler(response).await
}

async fn response_handler<T : DeserializeOwned>(data : Response) -> Result<T, Box<dyn Error>> {
  if data.status().is_success() {
    let data : T = data.json::<T>().await?;
    return Ok(data);
  }
  
  Err("Error".into())
}
