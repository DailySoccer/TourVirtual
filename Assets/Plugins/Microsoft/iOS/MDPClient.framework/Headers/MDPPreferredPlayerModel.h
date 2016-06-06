//
//  MDPPreferredPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPreferredPlayerModel.h"


#pragma mark - Interface
@interface MDPPreferredPlayerModel : _MDPPreferredPlayerModel

+ (NSArray *)preferredPlayerWithSport:(uint)sportType managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsPreferredPlayerWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
