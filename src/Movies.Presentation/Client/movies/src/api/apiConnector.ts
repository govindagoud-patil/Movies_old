import axios, { AxiosResponse } from "axios";
import { MovieDto } from "../models/movieDto";
import { GetMovieResponse } from "../models/getMoviesResponse";
import { API_BASE_URL } from "../../config"
import { GetMoviesByIdResponse } from "../models/getMovieByIdResponse";

const apiConnector = {

    getMovies: async (): Promise<MovieDto[]> => {

        try {
            const response: AxiosResponse<GetMovieResponse> =
                await axios.get(`${API_BASE_URL}/movies`)
            const movies = response.data.movieDtos.map(movie => ({
                ...movie,
                createDate: movie.createDate?.slice(0, 10) ?? ""
            }));
            return movies;
        } catch (error) {
            console.log('Error fetching moview', error);
            throw error;
        }
    },

    createMovie: async (movie: MovieDto): Promise<void> => {
        try {

            await axios.post<number>(`${API_BASE_URL}/movies`, movie);

        } catch (error) {
            console.log(error);
            throw error;
        }
    },


    editMovie: async (movie: MovieDto, movieId: number): Promise<void> => {
        try {

            await axios.post<number>(`${API_BASE_URL}/movies/${movieId}`, movie);

        } catch (error) {
            console.log(error);
            throw error;
        }
    },

    deleteMovie: async (movieId: number): Promise<void> => {
        try {

            await axios.delete<number>(`${API_BASE_URL}/movies/${movieId}`);

        } catch (error) {

            console.log(error);
            throw error;
        }
    },

    getMovieById: async (movieId: string): Promise<MovieDto | undefined> => {

        try {

            const response = await axios.get<GetMoviesByIdResponse>(`${API_BASE_URL}/movies/${movieId}`);
            return response.data.movieDto;

        } catch (error) {

            console.log(error);
            throw error;
        }
    }

}

export default apiConnector;