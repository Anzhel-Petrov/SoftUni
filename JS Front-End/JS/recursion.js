function solve(n) {
    if (n > 100) {
        return n - 10;
    }

    return solve(solve(n + 11));
}

solve(99);