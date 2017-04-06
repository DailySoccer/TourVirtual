//
//  MDPPagedPenyaModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPagedPenyaModel.h"


#pragma mark - Interface
@interface MDPPagedPenyaModel : _MDPPagedPenyaModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)penyasWithManagedObjectContext:(NSManagedObjectContext *)context;

@end
