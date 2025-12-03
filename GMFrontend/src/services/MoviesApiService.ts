import type MovieCardModel from "../models/MovieCardModel";

const _BaseUrl = "http://localhost:7372";
const BaseUrl = "http://localhost:3000";

export async function getPopularMovies(): Promise<MovieCardModel[]> {
  const response = await fetch(`${BaseUrl}/movies/popular`);
  const resultJson = await response.json();
  return resultJson.movies as Promise<MovieCardModel[]>;
}

export async function getMovieById(movieId: number): Promise<MovieCardModel> {
  const response = await fetch(`${BaseUrl}/movie/${movieId}`);
  const resultJson = await response.json();
  return (await resultJson.movie) as MovieCardModel;
}
