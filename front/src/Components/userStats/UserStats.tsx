import React, { useEffect, useState } from 'react';
import {
  TableHead,
  Paper,
  TableContainer,
  TableCell,
  TableBody,
  Table,
} from '@mui/material';
import { api } from '../../lib/axios';
import { StyledTableCell, StyledTableRow } from './styled';

type Row = {
  levelId: string;
  levelName: string;
  score: number;
  won: boolean;
  wavesCleared: number;
};

export default function UserStats() {
  const [tableData, setTableData] = useState<Row>();
  useEffect(() => {
    const fetch = async () => {
      const token = localStorage.getItem('token');
      const { data } = await api.get(
        'https://projectd.onebranch.dev/api/v1/scores/user',
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        },
      );

      setTableData(data.content);
    };

    fetch();
  }, []);
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <StyledTableRow>
            <StyledTableCell>Уровень</StyledTableCell>
            <StyledTableCell align="right">Счет</StyledTableCell>
            <StyledTableCell align="right">Волн пройдено</StyledTableCell>
          </StyledTableRow>
        </TableHead>
        <TableBody>
          <StyledTableRow
            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
          >
            <TableCell component="th" scope="row">
              {tableData?.levelName}
            </TableCell>
            <TableCell align="right">{tableData?.score}</TableCell>
            <TableCell align="right">{tableData?.wavesCleared}</TableCell>
          </StyledTableRow>
        </TableBody>
      </Table>
    </TableContainer>
  );
}
