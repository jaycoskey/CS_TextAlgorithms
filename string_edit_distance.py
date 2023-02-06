#!/usr/bin/env python3
# Find the string distance between two strings.
# Originally, Damerau-Levenshtein distance, supporting non-adjacent transpositions.
# Refactored, removing transposition support, but adding ability to find the operation chain.
# TODO: Get chain of ops to apply to the second string to obtain the first string.
# TODO: Restore support for transpositions.
# TODO: Convert tests to unittest.

from dataclasses import astuple, dataclass
from enum import Enum, Flag, auto
import sys
from typing import Tuple

import numpy as np

# ========================================

class OpType(Enum):
    Nil = auto()
    Del = auto()
    Ins = auto()
    Sub = auto()
    # Trn = auto()

    def __repr__(self):
        return self.name

    # def __str__(self):
    #     return self.name

@dataclass
class Op:
    op_type: OpType
    pos1: int = 0
    pos2: int = 0

    def __repr__(self):
        if self.op_type == OpType.Nil:
            return '_'
        elif self.op_type == OpType.Del:
            return f'{self.op_type.name[0:3]}({self.pos1})'
        elif self.op_type == OpType.Ins:
            return f'{self.op_type.name[0:3]}({self.pos1},{self.pos2})'
        elif self.op_type == OpType.Sub:
            return f'{self.op_type.name[0:3]}({self.pos1},{self.pos2})'

    # def __str__(self):
    #     return f'{self.op_type.name[0:3]}({self.pos1},{self.pos2})'

# ========================================

class VerboseFlag(Flag):
    SHOW_COST = auto()
    SHOW_OPS = auto()
    SHOW_STATUS = auto()

SHOW_NONE = VerboseFlag(0)
SHOW_ALL = VerboseFlag.SHOW_COST | VerboseFlag.SHOW_OPS | VerboseFlag.SHOW_STATUS

# ========================================

class StringDistanceData:
    @staticmethod
    def cost_deletion(c):
        return 1

    @staticmethod
    def cost_insertion(c):
        return 1

    @staticmethod
    def cost_substitution(c1, c2):
        return 1

    # @staticmethod
    # def cost_transposition(c1, c2):
    #     return 1

    def __init__(self, s1, s2, verbose_flags):
        self.s1 = s1
        self.s2 = s2

        m = len(s1)
        n = len(s2)
        if verbose_flags != SHOW_NONE:
            print(f'Finding Levelshtein distance data from {s1}(len={m}) to {s2}(len={n})')

        # Initialize distance table and list of transformations
        dist = np.arange((m + 1) * (n + 1)).reshape(m + 1, n + 1)
        dist[0, 0] = 0
        ops: Dict[Tuple[int, int], Op] = {}
        ops[(0, 0)] = Op(OpType.Nil, 0, 0)

        for i in range(1, m + 1):
            dist[i, 0] = dist[i - 1, 0] + StringDistanceData.cost_deletion(s1[i - 1])
            ops[(i, 0)] = Op(OpType.Del, i, 0)
        for j in range(1, n + 1):
            dist[0, j] = dist[0, j - 1] + StringDistanceData.cost_insertion(s2[j - 1])
            ops[(0, j)] = Op(OpType.Ins, 0, j)

        # Initialize record of where characters were last seen, to support non-adjacent transpositions.
        # char2lastpos = dict()
        # for c in s1 + s2:
        #     if not c in char2lastpos:
        #         char2lastpos[c] = 0

        # Note: Loop ranges [1..m+1], [1..n+1] ==> Set value of dist[(i, j)]
        #       Loop ranges [0..m], [0..n]     ==> Set value of dist[(i+1, j+1)]
        for i in range(1, m + 1):  # Iterate over s1
            # jPrevMatch = 0
            for j in range(1, n + 1):  # Interate over s2
                # last_seen_char = s2[j - 1]
                # iPrev = char2lastpos[last_seen_char]
                # jPrev = jPrevMatch

                if s1[i - 1] == s2[j - 1]:  # Both of the latest characters are identical
                    cost_new = dist[i - 1, j - 1]
                    ops[(i, j)] = Op(OpType.Nil, i, j)
                    # jPrevMatch = j
                else:  # Transformation needed
                    # Note: The computation of costs_incr is easily parallelizable.
                    costs_incr = np.array([StringDistanceData.cost_deletion(s1[i - 1]),
                                           StringDistanceData.cost_insertion(s2[j - 1]),
                                           StringDistanceData.cost_substitution(s1[i - 1], s2[j - 1])
                                           ])

                    # cost_trans = sys.maxsize
                    # if iPrev > 0 and jPrev > 0:
                    #     cost_tdel = sum([cost_deletion(s1[k]) for k in range(iPrev, i - 1)])
                    #     cost_tins = sum([cost_insertion(s2[k]) for k in range(jPrev, j - 1)])
                    #     cost_ttrans = cost_transposition(s1[iPrev - 1], s1[i - 1])
                    #     cost_trans = dist[iPrev - 1, jPrev - 1] + cost_tdel + cost_tins + cost_ttrans

                    # if verbose_flags & VerboseFlag.SHOW_STATUS:
                    #     s1_prev_str = f's1[{i-1}]={s1[i-1]}' if iPrev == 0 else ''
                    #     s2_prev_str = f's2[{j-1}]={s2[j-1]}' if jPrev == 0 else ''
                    #     sep = ', ' if s1_prev_str and s2_prev_str else ''
                    #     print(f'\t\tINFO: Not previously seen: {s1_prev_str}{sep}{s2_prev_str}.')

                    costs_base = np.array([dist[i - 1, j], dist[i, j - 1], dist[i - 1, j - 1]])  # DEL, INS, SUB
                    costs = costs_base + costs_incr
                    cost_new = min(costs)
                    min_index = 2 if costs[2] == cost_new else np.argmin(costs)  # Favor substitution

                    if min_index == 0:
                        ops[(i, j)] = Op(OpType.Del, i, j)
                    elif min_index == 1:
                        ops[(i, j)] = Op(OpType.Ins, i, j)
                    elif min_index == 2:
                        ops[(i, j)] = Op(OpType.Sub, i, j)
                    else:
                        raise ValueError(f'Unrecognized min_index: {min_index}')
                    # else:  # min_index == 3, cost_trans
                    #     ops[(i, j)] = Op(OpType.Trn, i, j)

                dist[i, j] = cost_new
                # End of s2 loop

            # char2lastpos[s1[i - 1]] = i
            # if verbose_flags != SHOW_NONE:
            #     print_output_delimiter('End of s1 loop')
            # End of s1 loop

        if verbose_flags & VerboseFlag.SHOW_COST == True:
            print('    Distance table:')
            print(dist)

        self.distance = dist[m, n]
        self.table = dist
        self.ops = ops

    def get_forward_ops_chain(self, verbose_flags=SHOW_NONE):
        """Returns a minimal cost "forward ops chain"---ops applied to s1 that yield s2."""
        (i, j) = self.table.shape
        i -= 1
        j -= 1
        ops_chain = []
        ops_chain_coords = []
        while self.table[(i,j)] > 0 or (i > 0 and j > 0):
            op = self.ops[(i, j)]
            ops_chain.insert(0, self.ops[(i, j)])
            ops_chain_coords.insert(0, (i, j))
            if op.op_type == OpType.Nil:  # or op.op_type == OpType.Trans:
                if i > 0: i -= 1
                if j > 0: j -= 1
            elif op.op_type == OpType.Del:
                if i == 0:
                    break
                i -= 1
            elif op.op_type == OpType.Ins:
                if j == 0:
                    break
                j -= 1
            elif op.op_type == OpType.Sub:
                i -= 1
                j -= 1
        return ops_chain

    def print_distance(self):
        print('    Distance from "{0:s}" to "{1:s}" is {2:d}.'.format(self.s1, self.s2, self.distance))

    def print_distances(self):
        print('    Distances from "{0:s}" to "{1:s}" = \n{2}.'.format(self.s1, self.s2, self.table))

    def print_forward_ops_chain(self):
        ops_chain = self.get_forward_ops_chain()
        print(f'Ops chain for {self.s1}, {self.s2}: {ops_chain}')

    def print_ops(self, indent='\t'):
        print(f'Ops table for "{self.s1}", "{self.s2}"')
        for i in range(0, self.table.shape[0]):
            print(indent, end='')
            for j in range(0, self.table.shape[1]):
                print('{0: <10}'.format(str(self.ops[(i, j)])), end='')
            print()


def get_string_chain(s1, s2, forward_ops_chain):
    chain = [s1]
    cur = s1

    ind_rel = 0
    for op in forward_ops_chain:
        (op_type, pos1, pos2) = astuple(op)
        if op_type == OpType.Nil:
            continue
        if op_type == OpType.Del:
            ind = pos1 + ind_rel - 1
            # print(f'\tINFO: get_string_chain: Deleting from {ind}')
            cur = cur[0:ind] + cur[ind + 1:]
            ind_rel -= 1
        elif op_type == OpType.Ins:
            ind = pos1 + ind_rel
            # print(f'\tINFO: get_string_chain: Inserting at {ind}')
            cur = cur[0:ind] + s2[pos2 - 1] + cur[ind:]
            ind_rel += 1
        elif op_type == OpType.Sub:
            ind = pos1 + ind_rel - 1
            # print(f'\tINFO: get_string_chain: Substituting at {ind}')
            cur = cur[0:ind] + s2[pos2 - 1] + cur[ind+1:]
            # ind_rel += 1
        # elif op_type == OpType.Trn:
        #     cur = cur[0:pos1] + cur[pos1+1:]
        # print(f'\tINFO: {op_type} ==> Appending {cur}')
        chain.append(cur)
    # print(f'\tINFO: string_chain_summary: {s1} ==> {cur} =?= {s2}')
    return chain


def test(verbose_flags=SHOW_NONE):
    def is_string_chain_valid(s1, s2, dist, table=None):
        data = StringDistanceData(s1, s2, SHOW_ALL if s1=='abc' and s2=='ca' else SHOW_NONE)
        if table is not None:
            assert(np.array_equal(data.table, table))
        forward_ops_chain = data.get_forward_ops_chain()
        string_chain = get_string_chain(s1, s2, forward_ops_chain)
        (verbose_flags & VerboseFlag.SHOW_COST)   and data.print_distances()
        (verbose_flags & VerboseFlag.SHOW_OPS)    and data.print_ops()
        (verbose_flags & VerboseFlag.SHOW_STATUS) and data.print_forward_ops_chain()
        (verbose_flags != SHOW_NONE) and print('=' * 40)
        return string_chain[-1] == s2

    def run_tests(test_data):
        (verbose_flags & VerboseFlag.SHOW_STATUS) and print('Running tests: ', end='')
        for test_input in test_data:
            print('.', end='')
            assert(is_string_chain_valid(*test_input))
        print()

    # Deletion
    d_lev_table_able  = np.array([[0,1,2,3,4], [1,1,2,3,4], [2,1,2,3,4], [3,2,1,2,3], [4,3,2,1,2], [5,4,3,2,1]])
    d_lev_point_pint  = np.array([[0,1,2,3,4], [1,0,1,2,3], [2,1,1,2,3], [3,2,1,2,3], [4,3,2,1,2], [5,4,3,2,1]])
    d_lev_ends_end    = np.array([[0,1,2,3], [1,0,1,2], [2,1,0,1], [3,2,1,0], [4,3,2,1]])

    d_lev_barfly_bar  = np.array([[0,1,2,3], [1,0,1,2], [2,1,0,1], [3,2,1,0],
                                  [4,3,2,1], [5,4,3,2], [6,5,4,3]])
    d_lev_barfly_bay  = np.array([[0,1,2,3], [1,0,1,2], [2,1,0,1], [3,2,1,1],
                                  [4,3,2,2], [5,4,3,3], [6,5,4,3]])
    d_lev_barfly_fly  = np.array([[0,1,2,3], [1,1,2,3], [2,2,2,3], [3,3,3,3],
                                  [4,3,4,4], [5,4,3,4], [6,5,4,3]])

    # Insertion
    d_lev_able_table = np.array([[0,1,2,3,4,5], [1,1,1,2,3,4], [2,2,2,1,2,3], [3,3,3,2,1,2], [4,4,4,3,2,1]])
    d_lev_pint_point = np.array([[0,1,2,3,4,5], [1,0,1,2,3,4], [2,1,1,1,2,3], [3,2,2,2,1,2], [4,3,3,3,2,1]])
    d_lev_end_ends   = np.array([[0,1,2,3,4], [1,0,1,2,3], [2,1,0,1,2], [3,2,1,0,1]])

    d_lev_bar_barfly = np.array([[0,1,2,3,4,5,6], [1,0,1,2,3,4,5], [2,1,0,1,2,3,4], [3,2,1,0,1,2,3]])
    d_lev_bay_barfly = np.array([[0,1,2,3,4,5,6], [1,0,1,2,3,4,5], [2,1,0,1,2,3,4], [3,2,1,1,2,3,3]])
    d_lev_fly_barfly = np.array([[0,1,2,3,4,5,6], [1,1,2,3,3,4,5], [2,2,2,3,4,3,4], [3,3,3,3,4,4,3]])

    # Mutation
    d_lev_port_sort  = np.array([[0,1,2,3,4], [1,1,2,3,4], [2,2,1,2,3], [3,3,2,1,2], [4,4,3,2,1]])
    d_lev_pint_punt  = np.array([[0,1,2,3,4], [1,0,1,2,3], [2,1,1,2,3], [3,2,2,1,2], [4,3,3,2,1]])
    d_lev_cord_core  = np.array([[0,1,2,3,4], [1,0,1,2,3], [2,1,0,1,2], [3,2,1,0,1], [4,3,2,1,1]])

    # Other
    d_lev_a_z          = np.array([[0,1], [1,1]])
    d_lev_abc_abc      = np.array([[0,1,2,3], [1,0,1,2], [2,1,0,1], [3,2,1,0]])
    d_lev_abc_ca       = np.array([[0,1,2],[1,1,1],[2,2,2],[3,2,3]])
    d_lev_abc_xyz      = np.array([[0,1,2,3], [1,1,2,3], [2,2,2,3], [3,3,3,3]])
    d_lev_board_border = np.array([[0,1,2,3,4,5,6], [1,0,1,2,3,4,5], [2,1,0,1,2,3,4],
                                   [3,2,1,1,2,3,4], [4,3,2,1,2,3,3], [5,4,3,2,1,2,3]])
    d_lev_ij_pq        = np.array([[0,1,2,3,4,5,6], [1,0,1,2,3,4,5], [2,1,0,1,2,3,4], [3,2,1,1,2,3,4],
                                   [4,3,2,2,2,3,4], [5,4,3,3,3,2,3], [6,5,4,4,4,3,2]])
    d_lev_miles_smile = np.array([[0,1,2,3,4,5], [1,1,1,2,3,4], [2,2,2,1,2,3],
                                  [3,3,3,2,1,2], [4,4,4,3,2,1], [5,4,5,4,3,2]])
    d_lev_sitting_kitten = np.array([[0,1,2,3,4,5,6], [1,1,2,3,4,5,6], [2,2,1,2,3,4,5], [3,3,2,1,2,3,4],
                                     [4,4,3,2,1,2,3], [5,5,4,3,2,2,3], [6,6,5,4,3,3,2], [7,7,6,5,4,4,3]])


    test_data = [
        # Del
        ('table',  'able',    1, d_lev_table_able),      # Del_1_head
        ('point',  'pint',    1, d_lev_point_pint),      # Del_1_body
        ('ends',   'end',     1, d_lev_ends_end),        # Del_1_tail

        ('barfly',   'fly',   3, d_lev_barfly_fly),      # Del_3_head
        ('barfly',   'bay',   3, d_lev_barfly_bay),      # Del_3_body
        ('barfly',   'bar',   3, d_lev_barfly_bar),      # Del_3_tail

        # Ins
        ('able',   'table',   1, d_lev_able_table),      # Ins_1_head
        ('pint',   'point',   1, d_lev_pint_point),      # Ins_1_body
        ('end',    'ends',    1, d_lev_end_ends),        # Ins_1_tail

        ('fly',    'barfly',  3, d_lev_fly_barfly),      # Ins_3_head
        ('bay',    'barfly',  3, d_lev_bay_barfly),      # Ins_3_body
        ('bar',    'barfly',  3, d_lev_bar_barfly),      # Ins_3_tail

        # Sub
        ('port',   'sort',    1, d_lev_port_sort),       # Sub_1_head
        ('pint',   'punt',    1, d_lev_pint_punt),       # Sub_1_body
        ('cord',   'core',    1, d_lev_cord_core),       # Sub_1_tail
        ('a_ij_z', 'a_pq_z',  2, d_lev_ij_pq),           # Sub_2_body

        # Xps
        # ('star',   'tsar',    1),                      # Xps_1_head
        # ('files',  'flies',   1),                      # Xps_1_body
        # ('boast',  'boats',   1),                      # Xps_1_tail
        # ('abcd',   'badc',    2),                      # Xps_2

        # Other
        ('a',       'z',      0, d_lev_a_z),             # Short
        ('abc',     'abc',    0, d_lev_abc_abc),         # Identical
        ('abc',     'xyz',    3, d_lev_abc_xyz),         # Disjoint
        ('board',   'border', 3, d_lev_board_border),    # Mix_Del_Ins
        ('miles',   'smile',  2, d_lev_miles_smile),     # Mix_Ins_Del
        ('sitting', 'kitten', 3, d_lev_sitting_kitten),  # Wikipedia
        ]

    run_tests(test_data)


if __name__ == '__main__':
    # test(verbose_flags=SHOW_NONE)
    test(verbose_flags=SHOW_ALL)
