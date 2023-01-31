import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { Routes, Route } from 'react-router-dom';
import './App.css';
import AppLayout from './components/AppLayout';
import MoviePage from './components/MoviePage';
import MoviesPage from './components/MoviesPage';

function App() {
    const queryClient = new QueryClient();
    return (
        <QueryClientProvider client={queryClient}>
            <Routes>
                <Route element={<AppLayout />}>
                    <Route path="/" element={<MoviesPage />} />
                    <Route path="/movie/:id" element={<MoviePage />} /> 
                </Route>
            </Routes>
        </QueryClientProvider>
    );
}

export default App;
