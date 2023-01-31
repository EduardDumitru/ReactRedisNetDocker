import { Box, Card, CardMedia, TextField } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import { trackPromise } from "react-promise-tracker";
import { useParams } from "react-router-dom";
import { getMovieById } from "../endpoints/Api";

export default function MoviePage() {
    const { id } = useParams();

    const { data, status } = useQuery({ queryKey: ['movie'], queryFn: async () => await trackPromise(getMovieById(id!)), retry: 3 });

    return (
        status === "success" &&
        <Box justifyContent="center" margin="auto" alignItems="center" border={1} borderRadius={2} width="90%" display="flex" flexDirection="column" pt={2} mt={2} mb={4}>
            <Box border={0} width="90%" m={3} justifyContent="center" display="flex" flexDirection="column" pt={2} mt={2} mb={4}>
                <TextField fullWidth value={data!.headline} key="headline" type="text" label="Headline" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.body} key="body" type="text" label="Body" multiline variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.year} key="year" type="number" label="Year" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.cert} key="cert" type="text" label="Cert" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.duration} key="duration" type="number" label="Duration" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.lastUpdated} key="lastUpdated" type="text" label="Last Updated" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.quote} key="quote" type="text" label="Quote" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.rating} key="rating" type="number" label="Rating" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.reviewAuthor} key="reviewAuthor" type="text" label="Review Author" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.skyGoId} key="skyGoId" type="text" label="SkyGo Id" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.skyGoUrl} key="skyGoUrl" type="url" label="SkyGo Url" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.sum} key="sum" type="text" label="Sum" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.synopsis} key="synopsis" multiline type="text" label="Synopsis" variant='filled' disabled margin="dense" />
                {data!.cardImages.map(cardImage => {
                    return (cardImage.image !== null && <Card raised sx={{'margin': 2}}>
                        <CardMedia component="img" height={cardImage.h} width={cardImage.w} alt=''
                            image={`data:${cardImage.extension};base64,${cardImage.image}`} />
                    </Card>)
                }
                )}
                {data!.keyArtImages.map(keyArtImage => {
                    return (keyArtImage.image !== null && <Card raised sx={{'margin': 2}}>
                        <CardMedia component="img" height={keyArtImage.h} width={keyArtImage.w} alt=''
                            image={`data:${keyArtImage.extension};base64,${keyArtImage.image}`} />
                    </Card>)
                }
                )}
                {data!.videos.map(video => {
                    return (
                        <>
                        <TextField fullWidth value={video.title} type="text" label="Video Title" variant='filled' disabled margin="dense" />
                        <TextField fullWidth value={video.type} type="text" label="Video Type" variant='filled' disabled margin="dense" />
                        <TextField fullWidth value={video.url} type="url" label="Video URL" variant='filled' disabled margin="dense" />
                        {video.alternatives.map(alternative => {
                            return (
                                <>
                                <TextField fullWidth value={alternative.quality} type="text" label="Alternative Quality" variant='filled' disabled margin="dense" />
                                <TextField fullWidth value={alternative.url} type="url" label="Alternative Url" variant='filled' disabled margin="dense" />
                                </>
                            )
                        })}
                        </>
                    )
                }
                )}
                {data!.directors.map(director => {
                    return (
                        <TextField fullWidth value={director.name} type="text" label="Video Title" variant='filled' disabled margin="dense" />
                    )
                })}
                {data!.genres.map(genre => {
                    return (
                        <TextField fullWidth value={genre} type="text" label="Genre" variant='filled' disabled margin="dense" />
                    )
                })}
                {data!.cast.map(actor => {
                    return (
                        <TextField fullWidth value={actor.name} type="text" label="Actor" variant='filled' disabled margin="dense" />
                    )
                })}
                
                <TextField fullWidth value={data!.viewingWindow.wayToWatch} key="wayToWatch" type="text" label="Way to Watch" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.viewingWindow.startDate} key="startDate" type="text" label="Start Date" variant='filled' disabled margin="dense" />
                <TextField fullWidth value={data!.viewingWindow.endDate} key="endDate" type="text" label="End Date" variant='filled' disabled margin="dense" />
            </Box>
        </Box>
        || <></>
    )
}