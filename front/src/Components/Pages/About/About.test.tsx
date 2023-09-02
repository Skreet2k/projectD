import React from 'react';
import { render, screen } from '@testing-library/react';
import About from "./About";

test('renders learn react link', () => {
    render(<About />);
    const about = screen.getByTestId('about');
    expect(about).toBeInTheDocument();
});
