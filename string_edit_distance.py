#!/usr/bin/env python3
# by Jay M. Coskey - entered into the public domain

import numpy as np

def deletionCost(c):
    return 1

def insertionCost(c):
    return 1

def substitutionCost(c1, c2):
    return 1

def transpositionCost(c1, c2):
    return 1

def damerauLevenshteinDistance(s1, s2, verbose=False):
    m = len(s1)
    n = len(s2)
    dist = np.arange((m + 2) * (n + 2)).reshape(m + 2, n + 2)

    dist[0, 0] = 0
    for i in range(1, m + 1):
        dist[i, 0] = dist[i - 1, 0] + deletionCost(s1[i - 1])
    for j in range(1, n + 1):
        dist[0, j] = dist[0, j - 1] + insertionCost(s2[j - 1])

    lastSeenCharPosition = dict()
    for c in s1 + s2:
        if not c in lastSeenCharPosition:
            lastSeenCharPosition[c] = 0

    for i in range(1, m + 1):
        jPrevMatch = 0
        for j in range(1, n + 1):
            lastSeenChar = s2[j - 1]
            iPrev = lastSeenCharPosition[lastSeenChar]
            jPrev = jPrevMatch

            # Both of the latest characters are identical
            if s1[i - 1] == s2[j - 1]:
                newCost = dist[i - 1, j - 1]
                jPrevMatch = j
            else:
                delCost = dist[i - 1, j] + deletionCost(s1[i - 1])
                insCost = dist[i, j - 1] + insertionCost(s2[j - 1])
                subCost = dist[i - 1, j - 1] + substitutionCost(s1[i - 1], s2[j - 1])
                newCost = min(delCost, insCost, subCost)

            if iPrev > 0 and jPrev > 0:

                tDelCost = 0
                for k in range(iPrev, i - 1):
                    tDelCost += deletionCost(s1[k])

                tInsCost = 0
                for k in range(jPrev, j - 1):
                    tInsCost += insertionCost(s2[k])  # Change to i to introduce subtle bug

                tTransCost = transpositionCost(s1[iPrev - 1], s1[i - 1])

                transCost = dist[iPrev - 1, jPrev - 1] + tDelCost + tInsCost + tTransCost
                newCost = min(newCost, transCost)
            dist[i, j] = newCost
        lastSeenCharPosition[s1[i - 1]] = i

    if verbose == True:
        for i in range(m + 1):
            if i > 0:
                print('')
            for j in range(n + 1):
                # print('d[{0:d}, {1:d}]={2:d}  '.format(i, j, dist[i, j]), end='')
                print('{0:d}  '.format(dist[i, j]), end='')
        print('')

    return dist[m, n]


def printDamerauLevenshteinDistance(s1, s2, verbose=False):
    d = damerauLevenshteinDistance(s1, s2, verbose)
    print('Distance between {0:s} and {1:s} is {2:d}'.format(s1, s2, d))


def test():
    # Insertion
    assert(1 == damerauLevenshteinDistance('able',  'table'))
    assert(1 == damerauLevenshteinDistance('pint',  'point'))
    assert(1 == damerauLevenshteinDistance('end',   'ends'))

    # Deletion
    assert(1 == damerauLevenshteinDistance('table', 'able'))
    assert(1 == damerauLevenshteinDistance('point', 'pint'))
    assert(1 == damerauLevenshteinDistance('ends',  'end'))

    # Mutation
    assert(1 == damerauLevenshteinDistance('port', 'sort'))
    assert(1 == damerauLevenshteinDistance('table', 'able'))
    assert(1 == damerauLevenshteinDistance('cord',  'core'))

    # Transposition
    assert(1 == damerauLevenshteinDistance('star',  'tsar'))
    assert(1 == damerauLevenshteinDistance('files', 'flies'))
    assert(1 == damerauLevenshteinDistance('boast', 'boats'))

    # Other
    assert(3 == damerauLevenshteinDistance('board', 'border'))


if __name__ == '__main__':
    test()
    # printDamerauLevenshteinDistance('miles', 'smile')
    # printDamerauLevenshteinDistance('abc', 'ca', True)

