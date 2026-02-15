class ViewedStorageFacade {
  private static Instance: ViewedStorageFacade | null = null;

  private constructor() { }
  public static getInstance(): ViewedStorageFacade {
    ViewedStorageFacade.Instance ??= new ViewedStorageFacade();
    return ViewedStorageFacade.Instance;
  }
}

export default ViewedStorageFacade;
