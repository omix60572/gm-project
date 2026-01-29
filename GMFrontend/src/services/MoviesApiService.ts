import type MovieCardModel from "../models/MovieCardModel";
import { ApiBaseUrl } from "./Endpoints";

/**
 * MoviesApiService handles api requests to retrieving movies data
 */
class MoviesApiService {
  /**
   * Retrieving popular movies data
   */
  async getPopularMovies(): Promise<MovieCardModel[]> {
    const response = await fetch(`${ApiBaseUrl}/movies/popular`);
    const resultJson = await response.json();
    return resultJson.movies as Promise<MovieCardModel[]>;
  }

  /**
   * Retrieving movie data
   * @param movieId number - Movie id to get movie data
   */
  async getMovieById(movieId: number): Promise<MovieCardModel> {
    const response = await fetch(`${ApiBaseUrl}/movie/${movieId}`);
    const resultJson = await response.json();
    return (await resultJson.movie) as MovieCardModel;
  }
}

// Export singleton instance
export const moviesApiService = new MoviesApiService();
export default MoviesApiService;
