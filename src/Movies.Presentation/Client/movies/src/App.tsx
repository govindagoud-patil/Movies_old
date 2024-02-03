import { Outlet, useLocation } from "react-router-dom";
import { Container } from "semantic-ui-react";
import MovieTable from "./Componets/Movies/MovieTable";

function App() {

    const loc = useLocation();
    
    return (
        <>
            {
              loc.pathname === '/' ? <MovieTable /> : (
                <Container className="container-style">
                    <Outlet />
                </Container>
                )
             }
        </>    
    )

}

export default App