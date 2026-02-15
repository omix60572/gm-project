class FavoritesStorageFacade {
  private static Instance: FavoritesStorageFacade | null = null;

  private constructor() { }
  public static getInstance(): FavoritesStorageFacade {
    FavoritesStorageFacade.Instance ??= new FavoritesStorageFacade();
    return FavoritesStorageFacade.Instance;
  }
}

export default FavoritesStorageFacade;
