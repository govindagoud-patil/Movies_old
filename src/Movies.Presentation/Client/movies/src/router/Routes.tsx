import { RouteObject,createBrowserRouter } from "react-router-dom"
import MovieForm from "../Componets/Movies/MovieForm"
import MovieTable from "../Componets/Movies/MovieTable.tsx"
import App from "../App.tsx"

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
                { path: 'createMovie', element: <MovieForm key='create' /> },
                { path: 'editMovie/:id', element: <MovieForm key='edit'  /> },
                { path: '*', element: <MovieTable /> }
            ]
    }
]

export const router = createBrowserRouter(routes)