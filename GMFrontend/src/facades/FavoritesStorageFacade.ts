import JsonUtils from "../common/JsonUtils";
import { LocalStorageFavoritesKey } from "../common/LocalStorageKeys";
import type FavoriteMovie from "../models/FavoriteMovie";
import LocalStorageService from "../services/LocalStorageService";

class FavoritesStorageFacade {
  private static Instance: FavoritesStorageFacade | null = null;
  private readonly localStorageService: LocalStorageService;

  private constructor() {
    this.localStorageService = LocalStorageService.getInstance();
  }
  public static getInstance(): FavoritesStorageFacade {
    FavoritesStorageFacade.Instance ??= new FavoritesStorageFacade();
    return FavoritesStorageFacade.Instance;
  }

  public addToFavorites(movie: FavoriteMovie) {
    const itemsStr = this.localStorageService.getValue(LocalStorageFavoritesKey);
    const sourceArray = JsonUtils.tryParseJsonString<FavoriteMovie[]>(itemsStr);
    if (sourceArray === null) {
      this.localStorageService.saveValue(LocalStorageFavoritesKey, [ movie ]);
    } else {
      sourceArray.push(movie);
      this.localStorageService.saveValue(LocalStorageFavoritesKey, sourceArray);
    }
  }

  public getFromFavorites(id: number): FavoriteMovie | null {
    const itemsStr = this.localStorageService.getValue(LocalStorageFavoritesKey);
    const sourceArray = JsonUtils.tryParseJsonString<FavoriteMovie[]>(itemsStr);
    if (sourceArray !== null && sourceArray.length > 0) {
      const resultMovie = sourceArray.find((x) => x.id === id);
      if (resultMovie !== null && resultMovie !== undefined) {
        return resultMovie;
      }
    }

    return null;
  }

  public removeFromFavorites(id: number) {
    const itemsStr = this.localStorageService.getValue(LocalStorageFavoritesKey);
    const sourceArray = JsonUtils.tryParseJsonString<FavoriteMovie[]>(itemsStr);
    if (sourceArray !== null && sourceArray.length > 0) {
      let arrayToSave: FavoriteMovie[] = [];
      for (const element of sourceArray) {
        if (element.id === id) {
          continue;
        } else {
          arrayToSave.push(element);
        }
      }

      this.localStorageService.saveValue(LocalStorageFavoritesKey, arrayToSave);
    }
  }

  public getAllFavorites(): FavoriteMovie[] {
    const itemsStr = this.localStorageService.getValue(LocalStorageFavoritesKey);
    const resultArray = JsonUtils.tryParseJsonString<FavoriteMovie[]>(itemsStr);
    if (resultArray !== null)
      return resultArray;

    return [];
  }
}

export default FavoritesStorageFacade;
