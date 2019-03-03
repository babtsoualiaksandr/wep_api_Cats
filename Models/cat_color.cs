public enum  cat_color: int {
    black = 1,
    white = 2,
    [NpgsqlTypes.PgName("black & white")]
    black_white =3,
    red =4,
    [NpgsqlTypes.PgName("red & white")]
    red_white = 5,
    [NpgsqlTypes.PgName("red & black & white")]
    red_black_white = 6
    }