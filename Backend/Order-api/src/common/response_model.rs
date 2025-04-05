use std::error::Error;
use std::fmt;

use axum::{http::StatusCode, response::IntoResponse, Json};
use serde::Serialize;
use utoipa::ToSchema;

use crate::constants::http_status_constant as constants;

#[derive(Serialize, ToSchema)]
pub struct Data<T> {
  pub data: T,
  pub message: String,
}

pub enum ApiResponse<T> {
  Ok(Data<T>),
  Created(Data<T>),
}

impl<T> IntoResponse for ApiResponse<T>
where
  T: Serialize,
{
  fn into_response(self) -> axum::response::Response {
    match self {
      Self::Ok(data) => (StatusCode::OK, Json(data)).into_response(),
      Self::Created(data) => (StatusCode::CREATED, Json(data)).into_response(),
    }
  }
}

#[derive(Debug)]
pub enum ApiError {
  BadRequest(String),
  NotFound(String),
  InternalServiceError(String),
}

impl fmt::Display for ApiError{
  fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
      write!(f, "{:?}", self)
  }
}

impl Error for ApiError {}

impl IntoResponse for ApiError {
  fn into_response(self) -> axum::response::Response {
    let (status, message) = match self {
      Self::BadRequest(message) => (
        StatusCode::BAD_REQUEST,
        if message.is_empty() { constants::BAD_REQUEST.to_string() } else { message },
      ),
      Self::NotFound(message) => (
        StatusCode::NOT_FOUND,
        if message.is_empty() { constants::NOT_FOUND.to_string() } else { message },
      ),
      Self::InternalServiceError(message) => (
        StatusCode::INTERNAL_SERVER_ERROR,
        if message.is_empty() { constants::INTERNAL_SERVER_ERROR.to_string() } else { message },
      ),
    };

    (status, Json(message)).into_response()
  }
}
