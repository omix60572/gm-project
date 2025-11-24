class MovieCardModel {
  id: number;
  imageUrl: string;
  title: string;
  description: string;
  releaseYear: number;

  constructor(
    id: number,
    imageUrl: string,
    title: string,
    description: string,
    releaseYear: number
  ) {
    this.id = id;
    this.imageUrl = imageUrl;
    this.title = title;
    this.description = description;
    this.releaseYear = releaseYear;
  }
}

export default MovieCardModel;
