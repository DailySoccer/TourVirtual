//
//  MDPTeamStatisticModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPTeamStatisticModel.h"


#pragma mark - Interface
@interface MDPTeamStatisticModel : _MDPTeamStatisticModel

+ (MDPTeamStatisticModel *)teamStatisticWithIdTeam:(NSString *)idTeam managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsTeamStatisticWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
