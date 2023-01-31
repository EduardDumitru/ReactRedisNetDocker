export interface Movie {
    cardImages: CardImage[];
    keyArtImages: CardImage[];
    body: string;
    id: string;
    cast: Person[];
    cert: string;
    class: string;
    directors: Person[];
    duration: number;
    genres: string[];
    headline: string;
    lastUpdated: Date;
    quote: string;
    rating: number;
    reviewAuthor: string;
    skyGoId: string;
    skyGoUrl: URL;
    sum: string;
    synopsis: string;
    url: URL;
    videos: Video[];
    year: string;
    viewingWindow: ViewingWindow;
}

export interface ViewingWindow {
    startDate: Date;
    wayToWatch: string;
    endDate: Date;
}

export interface Video {
    title: string;
    type: string;
    url: URL;
    alternatives: Alternative[];
}

export interface Alternative {
    quality: string;
    url: string;
}

export interface CardImage {
    image: string;
    h: number;
    w: number;
    extension: string;
}

export interface Person {
    name: string;
}