# Non-recursive-MergeSort

Non-recursive merge sort works by considering window sizes of 2,4,8,16.. 2^n over the input array. For each window ('k' in code below), all adjacent pairs of windows are merged into a temporary space, then put back into the array.
