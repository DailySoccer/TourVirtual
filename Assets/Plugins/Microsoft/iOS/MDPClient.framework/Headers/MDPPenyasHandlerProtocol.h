//
//  MDPPenyasHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 14/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPPenyasHandlerProtocol_h
#define MDPClient_MDPPenyasHandlerProtocol_h

#import "MDPPagedPenyaModel.h"


#pragma mark  - Response
typedef void (^MDPPenyasHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPPenyasHandlerProtocol
@protocol MDPPenyasHandlerProtocol <NSObject>

/*
 Get all the penyas name filtering by name.The results are returned paginated.
 */
+ (void)getPenyasWithCt:(uint)ct
                   text:(NSString *)text
        completionBlock:(void(^)(MDPPagedPenyaModel *content, NSError *error))completionBlock;

/*
 Listens to MDPPenya objetcs. Returns the elements for penya
 */
+ (NSArray *)penyas;

@end

#endif
