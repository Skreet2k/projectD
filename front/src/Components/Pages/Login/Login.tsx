import { Box, Button, TextField, Typography } from "@mui/material";
import React from "react";
import { Link } from "react-router-dom";

export default function Login() {
  return (
    <Box
      sx={{
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        height: "100dvh",
      }}
    >
      <Box
        sx={{
          background: "white",
          padding: "20px",
          boxShadow:
            "rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px",
          display: "flex",
          flexDirection: "column",
          gap: "16px",
        }}
      >
        <Typography component="h1">Войти</Typography>
        <TextField id="outlined-basic" label="Логин" variant="standard" />
        <TextField
          type="password"
          id="outlined-basic"
          label="Пароль"
          variant="standard"
        />
        <Button variant="contained">Войти в мир разработчиков</Button>
        <Link to={"/registration"}>Стать защитником</Link>
      </Box>
    </Box>
  );
}
