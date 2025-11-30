import type MovieCardModel from "../models/MovieCardModel";
import type MovieDetailsCardModel from "../models/MovieDetailsCardModel";
import { getCachedMovieById, saveMovieToCache } from "./LocalCacheService";

const _BaseUrl = "http://localhost:7372";
const BaseUrl = "http://localhost:3000";

export async function getPopularMovies(): Promise<MovieCardModel[]> {
  const response = await fetch(`${BaseUrl}/movies/popular`);
  const resultJson = await response.json();
  return resultJson.movies as Promise<MovieCardModel[]>;
}

export async function getMovieById(
  movieId: number
): Promise<MovieDetailsCardModel> {
  const cachedMovie = getCachedMovieById(movieId);

  if (cachedMovie === null) {
    const response = await fetch(`${BaseUrl}/movie/${movieId}`);
    const resultJson = await response.json();

    const movie = (await resultJson.movie) as MovieDetailsCardModel;
    saveMovieToCache(movie);
    return movie;
  }

  return cachedMovie;
}
