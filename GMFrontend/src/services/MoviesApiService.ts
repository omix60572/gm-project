import { GetMovieApi, GetPopularMoviesApi } from "../common/Endpoints";
import type MovieCardModel from "../models/MovieCardModel";
import ApiFacade from "../facades/ApiFacade";

class MoviesApiService {
  private static Instance: MoviesApiService | null = null;

  private readonly apiFacade: ApiFacade;

  private constructor() {
    this.apiFacade = ApiFacade.getInstance();
  }
  public static getInstance(): MoviesApiService {
    MoviesApiService.Instance ??= new MoviesApiService();
    return MoviesApiService.Instance;
  }

  public async getPopularMovies(): Promise<MovieCardModel[]> {
    const response = await this.apiFacade.get<{ movies: MovieCardModel[] }>(GetPopularMoviesApi);
    return response.movies;
  }

  public async getMovieById(movieId: number): Promise<MovieCardModel> {
    const response = await this.apiFacade.get<{ movie: MovieCardModel }>(`${GetMovieApi}/${movieId}`);
    return response.movie;
  }
}

export default MoviesApiService;
