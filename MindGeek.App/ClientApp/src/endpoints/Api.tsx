import { Movie } from "../data/Movie";

export async function getMovies(): Promise<Movie[]> {
    const response = await fetch(new URL(`${process.env.REACT_APP_API_BASE_URL}\\movie\\all`), {
        method: 'GET',
        headers: { 'Content-Type': 'application/json'}
    });

    if (!response.ok) {
        console.error('Error getting movies');
        return [];
    }

    const responseData = await response.json();
    return responseData as Movie[];
}

export async function getMovieById(id: string): Promise<Movie | null> {
    const response = await fetch(new URL(`${process.env.REACT_APP_API_BASE_URL}\\movie\\${id}`), {
        method: 'GET',
        headers: { 'Content-Type': 'application/json'}
    });

    if (!response.ok) {
        console.error('Error getting movies');
        return null;
    }

    const responseData = await response.json();
    return responseData as Movie;
}