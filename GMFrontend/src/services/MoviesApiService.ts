import type MovieCardModel from "../models/MovieCardModel";

const BaseUrl = "http://localhost:7372";
const _BaseUrl = "http://localhost:3000";

export async function getPopularMovies(): Promise<MovieCardModel[]> {
  const response = await fetch(`${BaseUrl}/movies/popular`);
  const resultJson = await response.json();
  return resultJson.movies as Promise<MovieCardModel[]>;
}
