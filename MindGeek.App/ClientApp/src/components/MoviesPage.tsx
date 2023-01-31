import { Box, Card, CardActionArea, CardContent, CardMedia, Stack, Typography } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import { trackPromise } from "react-promise-tracker";
import { Link, useNavigate } from "react-router-dom";
import { CardImage } from "../data/Movie";
import { getMovies } from "../endpoints/Api";

export default function MoviesPage() {
    const navigate = useNavigate();

    const { data, status } = useQuery({ queryKey: ['movies'], queryFn: async () => await trackPromise(getMovies()), refetchOnMount: false, refetchOnWindowFocus: false, retry: 3 });

    return (
        <Box m={3} justifyContent="center" margin="auto" alignItems="center" border={1} borderRadius={2} width="80%" display="flex" flexDirection="column" pt={2} mt={2} mb={4}>
            <Stack m={2} width="60%">

                {status == "success" && data.map(movie => {
                    var cardImage = movie.cardImages.find(x => x.image !== null);
                    if (cardImage === undefined) {
                        cardImage = movie.keyArtImages.find(x => x.image !== null);
                        if (cardImage === undefined) {
                            cardImage = {image: '', extension: '', h: 100, w: 100} as CardImage;
                        }
                    }
                    return (<Card sx={{ width: "100%" }} key={movie.id}>

                        <CardActionArea component={Link} to={`/movie/${movie.id}`}>
                            <CardMedia
                                component="img"
                                height={cardImage.h}
                                width={cardImage.w}
                                image={`data:${cardImage.extension};base64,${cardImage.image}`}
                                alt={movie.headline}
                            />
                            <CardContent>
                                <Typography gutterBottom variant="h5" component="div">
                                    {movie.headline}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {movie.synopsis}
                                </Typography>
                            </CardContent>
                        </CardActionArea>
                    </Card>)
                })}
            </Stack>

        </Box>

    )
}