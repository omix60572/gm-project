import { useEffect, useState } from "react";
import MoviesList from "./MoviesList";
import SearchBar from "./SearchBar";
import type MovieCardModel from "../models/MovieCardModel";
import MoviesApiService from "../services/MoviesApiService";
import { StringEmpty } from "../common/CommonConst";
import Utils from "../common/Utils";

interface FavoritesViewProps {
  searchPlaceholder?: string;
}

function FavoritesView({ searchPlaceholder }: Readonly<FavoritesViewProps>) {
  const [movies, setMovies] = useState<MovieCardModel[]>([]);
  const [error, setError] = useState(StringEmpty);
  const [loading, setLoading] = useState(true);
  const moviesApiService = MoviesApiService.getInstance();

  // Second param just empty arr, for single call only on component creation (render)
  useEffect(() => {
    const loadPopularMovies = async () => {
      try {
        const popularMoviesResponse: MovieCardModel[] =
          await moviesApiService.getFavoritesMovies();

        if (!Utils.isNullOrUndefined(popularMoviesResponse)) {
          setMovies(popularMoviesResponse);
        }
      } catch (e) {
        console.log(e);
        setError("Falied to load movies...");
      } finally {
        setLoading(false);
      }
    };

    loadPopularMovies();
  }, []);

  // TODO: Обработка ошибок, отображение пользователю
  return (
    <>
      <SearchBar placeholder={searchPlaceholder} />
      <MoviesList movies={movies} />
    </>
  );
}

export default FavoritesView;
