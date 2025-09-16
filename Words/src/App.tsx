import './App.css'
import { Route, Routes } from 'react-router-dom'
import { HomePage } from './pages/HomePage/HomePage.tsx'
import { DictionaryPage } from './pages/DictionaryPage/DictionaryPage.view.tsx'
import { AddWordPage } from './pages/AddWordPage/AddWordPage.tsx'
import { EditWordPage } from './pages/EditWordPage/EditWordPage.view.tsx'
import { TestTranslationPage } from './pages/TestTranslationPage/TestTranslationPage.view.tsx'
import { ResultPage } from './pages/ResultPage/ResultPage.view.tsx'

function App() {
  return (
    <Routes>
      <Route path="/" element={<HomePage />}></Route>
      <Route path="/dictionary" element={<DictionaryPage/>}></Route>
      <Route path="/new-word" element={<AddWordPage/>}></Route>
      <Route path="/edit-word/:id" element={<EditWordPage/>}></Route>
      <Route path="/test" element={<TestTranslationPage/>}></Route>
      <Route path="/result" element={<ResultPage/>}></Route> 
    </Routes>
  )
}

export default App