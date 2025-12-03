import type MovieCardModel from "../models/MovieCardModel";
import { ApiBaseUrl } from "./Endpoints";

export async function getPopularMovies(): Promise<MovieCardModel[]> {
  const response = await fetch(`${ApiBaseUrl}/movies/popular`);
  const resultJson = await response.json();
  return resultJson.movies as Promise<MovieCardModel[]>;
}

export async function getMovieById(movieId: number): Promise<MovieCardModel> {
  const response = await fetch(`${ApiBaseUrl}/movie/${movieId}`);
  const resultJson = await response.json();
  return (await resultJson.movie) as MovieCardModel;
}
