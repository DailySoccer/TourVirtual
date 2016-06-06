//
//  MDPStatisticTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPStatisticTypeModel.h"

#define MDPStatisticTypeModelTypeRedCards        @"# Red cards"
#define MDPStatisticTypeModelTypeYellowCards     @"# Yellow cards"
#define MDPStatisticTypeModelTypeGames           @"# Games"
#define MDPStatisticTypeModelTypeMinsPlayed      @"# Mins played"
#define MDPStatisticTypeModelTypeGoals           @"# Goals"


#pragma mark - Interface
@interface MDPStatisticTypeModel : _MDPStatisticTypeModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
